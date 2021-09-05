/* Copyright 2019-2021 Canaan Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma once
#include <nncase/runtime/datatypes.h>
#include <nncase/runtime/small_vector.hpp>
#include <optional>
#include <ranges>

namespace nncase::ir {
struct unknown_dim_t {};

inline constexpr unknown_dim_t unknown_dim;

enum dim_kind_t { dim_fixed = 0, dim_unknown = 1 };

/** @brief Dimension */
struct dim_t {
    /** @brief Initialize an unknown dim */
    constexpr dim_t(unknown_dim_t = unknown_dim) noexcept
        : kind(dim_unknown), value(0) {}

    /** @brief Initialize an fixed dim */
    constexpr dim_t(int64_t value) noexcept : kind(dim_fixed), value(value) {}

    /** @brief Is this a fixed dim */
    bool is_fixed() const noexcept { return kind == dim_fixed; }
    /** @brief Is this an unknown dim */
    bool is_unknown() const noexcept { return kind == dim_unknown; }

    dim_kind_t kind;
    int64_t value;
};

struct unranked_shape_t {};

inline constexpr unranked_shape_t unranked_shape;

struct invalid_shape_t {};

inline constexpr invalid_shape_t invalid_shape;

/** @brief Shape type */
class NNCASE_API shape_t {
    enum shape_kind_t {
        shape_kind_fixed,
        shape_kind_invalid,
        shape_kind_unranked,
        shape_kind_has_unknown_dim
    };

  public:
    using value_type = dim_t;

    /** @brief Initialize an unranked shape */
    shape_t(unranked_shape_t = unranked_shape) noexcept
        : kind_(shape_kind_unranked) {}

    /** @brief Initialize an invalid shape */
    shape_t(invalid_shape_t) noexcept : kind_(shape_kind_invalid) {}

    /** @brief Initialize a ranked shape */
    shape_t(std::initializer_list<dim_t> dims)
        : kind_(kind_of(dims)), dims_(dims) {}

    /** @brief Initialize a fixed shape */
    shape_t(std::initializer_list<int64_t> dims) : kind_(shape_kind_fixed) {
        dims_.reserve(dims.size());
        std::ranges::transform(dims, std::back_inserter(dims_),
                               [](int64_t dim) -> dim_t { return dim; });
    }

    /** @brief Get kind */
    shape_kind_t kind() const noexcept { return kind_; }

    /** @brief Is this a fixed shape */
    bool is_fixed() const noexcept { return kind() == shape_kind_fixed; }
    /** @brief Is this a scalar */
    bool is_scalar() const noexcept {
        return kind() == shape_kind_fixed && dims_.empty();
    }
    /** @brief Is this an ranked shape */
    bool is_ranked() const noexcept { return is_fixed() || has_unknown_dim(); }
    /** @brief Is this an unranked shape */
    bool is_unranked() const noexcept { return kind() == shape_kind_unranked; }
    /** @brief Has at least one unknown dimension */
    bool has_unknown_dim() const noexcept {
        return kind() == shape_kind_has_unknown_dim;
    }
    /** @brief Is this an invalid shape */
    bool is_invalid() const noexcept { return kind() == shape_kind_invalid; }

    /** @brief Get dimensions */
    std::span<const dim_t> dims() const noexcept { return dims_; }

    /** @brief Get rank */
    std::optional<size_t> rank() const noexcept {
        return is_ranked() ? std::make_optional(dims_.size()) : std::nullopt;
    }

    auto begin() const noexcept { return dims_.cbegin(); }
    auto end() const noexcept { return dims_.cend(); }

    const dim_t &front() const { return dims_.front(); }
    const dim_t &back() const { return dims_.back(); }

    /** @brief Get dimension */
    const dim_t &dim(size_t index) const { return dims_.at(index); }
    const dim_t &operator[](size_t index) const { return dim(index); }

    /** @brief Set dimension */
    void dim(size_t index, dim_t value);

    /** @brief Place a new dim at back */
    void push_back(dim_t value);
    const dim_t &emplace_back(dim_t value);
    /** @brief Place a new dim */
    const dim_t *emplace(const dim_t *position, dim_t value);

    /** @brief Remove the dim at back */
    void pop_back();

  private:
    template <std::ranges::range R>
    static shape_kind_t kind_of(R &&range) noexcept {
        return std::ranges::any_of(
                   range, [](const dim_t &dim) { return dim.is_unknown(); })
                   ? shape_kind_has_unknown_dim
                   : shape_kind_fixed;
    }

    void update_kind(shape_kind_t before_kind,
                     dim_kind_t new_dim_kind) noexcept;

  private:
    shape_kind_t kind_;
    itlib::small_vector<dim_t, 4> dims_;
};
} // namespace nncase::ir
